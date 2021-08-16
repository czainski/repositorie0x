using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using System.Threading.Tasks;
using System;
using WebApp.Models
;

namespace WebApp.Controllers {

    [ApiController]
    [Route("api/[controller]")]
    public class CompanysController : ControllerBase 
    {
        IRepository _repository   = null;
        bool  _dataBaseExist =  true;
       
        public  CompanysController(Context context)
        {
            if((_repository = new Repository(context)) == null) 
                                _dataBaseExist =  false;
        }
         //
        [HttpGet("all")]
        public async Task<Object> Get() 
        {    
            if (_dataBaseExist)
            {
                try
                {
                    return await _repository.GetCompanys();
                }
                catch (Exception ex)
                {
                    return new Message { Alert = "Exception:Get:all: " + ex.GetType().FullName };
                }
            }
            return new Message { Alert = "Not Found the DataBase!" };
        }
        //
        [HttpGet("any")]
        public async Task<object> Get(long id)
        {
            if (_dataBaseExist)
            {
                try
                {
                    return await _repository.GetCompany(id);
                }
                catch (Exception ex)
                {
                    return new Message { Alert = "Exception:Get:all: " + ex.GetType().FullName };
                }
            }
            return new Message { Alert = "Not Found the DataBase!" };
        }
        //
        [HttpPost("create")]
        public async Task<object> Post([FromBody] Company company)
        {
            if (_dataBaseExist)
            {
                try
                {
                    return await _repository.CreateCompany(company);
                }
                catch (Exception ex)
                {
                    return new Message { Alert = "Exception:Get:all: " + ex.GetType().FullName };
                }
            }
            return new Message { Alert = "Not Found the DataBase!" };
        }
        //
        [HttpPost("search")]
        public async Task<object> Post([FromBody] Criterion criterion)
        {
            if (_dataBaseExist)
            {
                try
                {
                    return await _repository.CompanysSearcher(criterion);
                }
                catch (Exception ex)
                {
                    return new Message { Alert = "Exception:Get:all: " + ex.GetType().FullName };
                }
            }
            return new Message { Alert = "Not Found the DataBase!" };
        }
        //
        [HttpPut("update")]
        public async Task<object> Put(int id, [FromBody] Company company)
        {
            if (_dataBaseExist)
            {
                try
                {
                    await _repository.UpdateCompany(id, company);
                    return company;
                }
                 catch (Exception ex)
                {
                    return new Message { Alert = "Exception:Get:all: " + ex.GetType().FullName };
                }
            }
            return new Message { Alert = "Not Found the DataBase!" };
        }

        [HttpDelete("delete")]
        public async Task<object> Delete(int id)
        {
            if (_dataBaseExist)
            {
                try
                {
                    await _repository.DeleteCompany(id);
                    return new Message { Alert = "Delete the Company Id = " + id};
                }
                catch (Exception ex)
                {
                    return new Message { Alert = "Exception:Get:all: " + ex.GetType().FullName };
                }
            }
            return new Message { Alert = "Not Found the DataBase!" };
        }
    }//
}//

