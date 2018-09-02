using Constants;
using Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace POPAPI.Controllers
{
    public class MaterialController : ApiController
    {
        private IBaseService<Material> _materialService;
        public MaterialController(IBaseService<Material> materialService)
        {
            _materialService = materialService;
        }
        public async Task<HttpResponseMessage> PostAsync([FromBody] Material materialForm)
        {
            try
            {
                if (_materialService != null)
                {
                    Material material = await _materialService.AddAsync(materialForm);
                    if (material != null)
                    {
                        return Request.CreateResponse(HttpStatusCode.Created, material);
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
                if (_materialService != null)
                {
                    Material material = await _materialService.FindAsync(s => s.MaterialId == id);
                    if (material != null)
                    {
                        if (material.Status.Equals(MaterialStatus.Deleted))
                        {
                            return Request.CreateResponse(HttpStatusCode.NoContent);
                        }
                        if (await _materialService.DeleteAsync(material) > 0)
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
        public async Task<HttpResponseMessage> Put([FromBody]Material materialForm)
        {
            try
            {
                Material material = await _materialService.UpdateAsync(materialForm, materialForm.MaterialId);
                if (material != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, material);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

        public async Task<HttpResponseMessage> GetAsync([FromUri]int number, int material)
        {
            try
            {
                IEnumerable<Material> materials = await _materialService.GetAllAsync(number, material);
                return Request.CreateResponse(HttpStatusCode.OK, materials);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Bad Request");
        }

    }
}
 
