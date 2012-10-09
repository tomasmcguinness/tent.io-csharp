using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TentIo.Client.Formatters
{
    public class TentJsonMediaTypeFormatter : JsonMediaTypeFormatter
    {
        public TentJsonMediaTypeFormatter()
        {
            SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/vnd.tent.v0+json"));
        }

        public override Task<object> ReadFromStreamAsync(Type type, System.IO.Stream readStream, System.Net.Http.HttpContent content, IFormatterLogger formatterLogger)
        {

            return base.ReadFromStreamAsync(type, readStream, content, formatterLogger);
        }

        public override bool CanReadType(Type type)
        {
            return true;
        }
    }
}
