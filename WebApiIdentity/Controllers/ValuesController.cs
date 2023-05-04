using Microsoft.AspNetCore.Mvc;
using WebApiIdentity.Dtos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

// Api da controller isimleri s takısı ile tanımlanır ve api/ ile endpoint başlamasıda bir standarttır.

namespace WebApiIdentity.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ValuesController : ControllerBase
  {
    // GET: api/<ValuesController>
    [HttpGet]
    public IActionResult Get()
    {
      var values = new List<ValueDto>();
      values.Add(new ValueDto { Id = 1, Name = "Value1" });
      values.Add(new ValueDto { Id = 2, Name = "Value2" });

      return Ok(values); // Status Code 200
    }

    // GET api/<ValuesController>/5
    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
      return Ok(new ValueDto { Id = id, Name = $"Value{id}" });
    }

    // POST api/<ValuesController>
    [HttpPost]
    public IActionResult Post([FromBody] ValueDto value)
    {
      // yeni bir kaynak oluşturma endpointi
      // Bodyden gelen değerler [FromBody] ile yakalarız
      // Post Created 201 döndürürüz.
      return Created($"api/values/{value.Id}", value);
    }

    // PUT api/<ValuesController>/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] ValueDto value)
    {
      // hangi idli kaynak güncellenecek, ve güncel değer ne
      // kaynak güncelleme endpoint, 

      return NoContent(); // 204 Güncelleme ve Silme 204 Döner.
    }

    // DELETE api/<ValuesController>/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id, [FromHeader] string lang)
    {
      // id ile silincek kaynak bilgisini route dan okuruz.
      return NoContent(); // 204 No Content dönüş bir standarttır. silme işlemlerinde
    }

    [HttpDelete] // route değeri koymadık queryString oldu.
    public IActionResult DeleteByName([FromQuery] string name)
    {

      if (string.IsNullOrEmpty(name))
        return NotFound(); // Kaynak bulunamadı.

      // id ile silincek kaynak bilgisini route dan okuruz.
      return NoContent(); // 204 No Content dönüş bir standarttır. silme işlemlerinde
    }
  }
}
