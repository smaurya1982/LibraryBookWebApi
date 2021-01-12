using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Results ;
using System.Web.Http;
using LibraryMangment.Services;
using LibraryMangment.Models;
using System.Web.Http.Cors;
using Newtonsoft.Json;
using System.Text;

namespace LibraryMangment.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
   
    public class BookController : ApiController
    {
       
        IBookRepository iBookRepository= new BookRepository();
        Message message = new Message();

        public IHttpActionResult GetAllBook()
        {
            var result = iBookRepository.GetAllBook();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        // GET api/Employee/5
        //[Route("api/Book/Get/{id:int}")]
        public IHttpActionResult GetBook(int id)
        {
            //iBookRepository = new BookRepository();
            try
            {
                var result = iBookRepository.Get(id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                    //return NotFound(ServicesExtension.NoProductFound());
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
                //return BadRequest(ServicesExtension.ErrorOut(ex.Message));
            }

           
        }


        // POST api/values
        [HttpPost]
        // [Route("api/CreateBook")]
        //[JsonRequired()]
        public IHttpActionResult CreateBook([FromBody] BookViewModel BookViewModel)
        {
            try
            {
                var result = iBookRepository.InserBook(BookViewModel);
               var a= JsonConvert.SerializeObject(result);
                Message deserializedProduct = JsonConvert.DeserializeObject<Message>(a);

                if (result.Status == "200") return Ok(deserializedProduct);
                else return NotFound();
            }
            catch (Exception ex)
            {
               // return BadRequest();
                return BadRequest(ServicesExtension.ErrorOut(ex.Message).ToString());
            }
            //JsonConvert.SerializeObject(result)
            //JsonConvert.SerializeObject(result), Encoding.UTF8, "application/json"



        }

        // PUT api/values/5
        [HttpPut]
        // [Route("api/Book/UpdateBook/employeeEntity")]
        public IHttpActionResult UpdateBook([FromBody] BookViewModel BookViewModel)
        {
            try
            {
                var result = iBookRepository.UpdateBook(BookViewModel);
                if (result.Status == "200")
                {
                    return Ok(result);
                }

                else
                {
                    return NotFound();
                    //return NotFound(result);
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
               // return BadRequest(ServicesExtension.ErrorOut(ex.Message));
            }

           
        }

        // DELETE api/values/5
        [HttpDelete]
      // [Route("api/Book/DeleteBook/{id:int}")]
        public IHttpActionResult DeleteBook(int id)
        {
            try
            {
                var result = iBookRepository.DeleteBook(id);
                if (result.Status == "200")
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                   // return NotFound(result);
                }
            }
            catch (Exception Ex)
            {
                return BadRequest();
                //return BadRequest(ServicesExtension.ErrorOut(Ex.Message));
            }

           
        }
    }
}
