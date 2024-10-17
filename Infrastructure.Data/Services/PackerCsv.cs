using Core.Interfaces;
using CsvHelper;
using Infrastrucrure.Dto;
using Infrastrucrure.Interfaces;
using Npgsql.Internal;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastrucrure.Services
{
    internal class PackerCsv : IPacker<Stream, IEntity>
    {
        public Stream Pack(IEnumerable<IEntity> data)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            var memoryStream = new MemoryStream();
            
                using (var writer = new StreamWriter(memoryStream, Encoding.GetEncoding(1251), leaveOpen: true))
                {
                    using (var csv = new CsvWriter(writer, CultureInfo.GetCultureInfo("ru-RU"), leaveOpen: true))
                    {
                        csv.WriteField("Имя");
                        csv.WriteField("Аэропорт отправления");
                        csv.WriteField("Аэропорт прибытия");
                        csv.WriteField("Время отправления");
                        csv.WriteField("Время прибытия");
                        csv.NextRecord();
                        foreach (var row in data)
                        {
                            csv.WriteField((row as Trip)?.Name);
                            csv.WriteField((row as Trip)?.DepAirport);
                            csv.WriteField((row as Trip)?.ArrAirport);
                            csv.WriteField((row as Trip)?.DepTime);
                            csv.WriteField((row as Trip)?.ArrTime);
                            csv.NextRecord();
                        }
                        writer.Flush();
                        memoryStream.Seek(0, SeekOrigin.Begin);
                    }
                }
                return memoryStream;
        }
    }
}
