using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Web.Http;
using Constants;
using Models;
using Services;

namespace POPAPI.Controllers
{
    public class SizeController : ApiController
    {
        private IBaseService<Size> _sizeService;

        public SizeController(IBaseService<Size> sizeService)
        {
            _sizeService = sizeService;
        }

        public async Task<HttpResponseMessage> PostAsync([FromBody] Size sizeForm)
        {
            try
            {
                if (_sizeService != null)
                {
                    Size size = await _sizeService.AddAsync(sizeForm);
                    if (size != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, size);
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        public async Task<HttpResponseMessage> DeleteAsync(long id)
        {
            try
            {
                if (_sizeService != null)
                {
                    Size size = await _sizeService.FindAsync(s => s.SizeId == id);
                    if (size != null)
                    {
                        if (size.Status.Equals(SizeStatus.Deleted))
                        {
                            return Request.CreateResponse(HttpStatusCode.NoContent);
                        }
                        if (await _sizeService.DeleteAsync(size) > 0)
                        {
                            return Request.CreateResponse(HttpStatusCode.OK);
                        }
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NoContent);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        public async Task<HttpResponseMessage> Put([FromBody]Size sizeForm)
        {
            try
            {
                Size size = await _sizeService.UpdateAsync(sizeForm, sizeForm.SizeId);
                if (size!=null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK,size);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        public async Task<HttpResponseMessage> GetAsync([FromUri]int number, int size)
        {
            try
            {
                IEnumerable<Size> sizes = await _sizeService.GetAllAsync(number, size);
                return Request.CreateResponse(HttpStatusCode.OK, sizes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

    }
}
