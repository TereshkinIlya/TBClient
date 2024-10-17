using Core.Interfaces;
using Infrastrucrure.Interfaces;
using System.Net.Mime;

namespace Infrastrucrure
{
    internal class TgBotRequestHandler : IRequestHandler<Stream, string>
    {
        private ISeacher<IEnumerable<IEntity>, string> Seacher { get; set; }
        private IPacker<Stream, IEntity> Csv {  get; set; }
        public TgBotRequestHandler(ISeacher<IEnumerable<IEntity>, string> seacher,
                                IPacker<Stream, IEntity> packer)
        {
            Seacher = seacher;
            Csv = packer;
        }
        public async Task<Stream> HandleRequestAsync(string message)
        {
            var data = await Seacher.GetDataAsync(message);
            var result = Csv.Pack(data);
            return result;
        }
    }
}
