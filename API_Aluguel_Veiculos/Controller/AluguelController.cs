using API_Aluguel_de_carros.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Aluguel_de_carros.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : ControllerBase
    {
        private static List<Carro> carros = new List<Carro>();

        [HttpPost]
        public ActionResult<List<Carro>>
            AddCarro(Carro newCar)
        {

            if (newCar.Id == 0)
            {
                newCar.alugado = false;
                newCar.Id = (carros.Count == 0) ? 1 : carros[carros.Count - 1].Id + 1;
            }

            carros.Add(newCar);

            return Ok(carros);
        }


        [HttpPut("{id_modelo}")]
        public ActionResult<List<Carro>>
            AlugarCarro(String id_modelo)
        {
            Carro carroAluguel = null;

            if (int.TryParse(id_modelo, out int id)) {
                carroAluguel = carros.Find(x => x.Id == id);
            }

            if (carroAluguel == null)
            {
                carroAluguel = carros.Find(x => x.modelo == id_modelo);
            }

            if (carroAluguel != null)
            {
                carroAluguel.alugado = true;
                return Ok(carroAluguel);
            }

            return NotFound("Não foi buscar por modelo ou id");

        }

        [HttpGet]
        public ActionResult<List<Carro>>
        MostrarTodosOsCarros()
        {
            return Ok(carros);

        }

        [HttpGet("find")]
        public ActionResult<List<Carro>>
     MostrarAlugado([FromQuery] string id_modelo)
        {
            Carro carroAluguel = null;

            if (int.TryParse(id_modelo, out int id))
            {
                carroAluguel = carros.Find(x => x.Id == id);
            }

            if (carroAluguel == null)
            {
                carroAluguel = carros.Find(x => x.modelo == id_modelo);
            }

            if (carroAluguel != null)
            {
                return Ok(carroAluguel.alugado);
            }

            return NotFound("Não foi buscar por modelo ou id");
        }

        [HttpPut("/api/Aluguel/devolucao/{id_modelo}")]
        public ActionResult<List<Carro>>
          DevolucaoCarro(String id_modelo)
        {
            Carro carroAluguel = null;

            if (int.TryParse(id_modelo, out int id))
            {
                carroAluguel = carros.Find(x => x.Id == id);
            }

            if (carroAluguel == null)
            {
                carroAluguel = carros.Find(x => x.modelo == id_modelo);
            }

            if (carroAluguel != null)
            {
                carroAluguel.alugado = false;
                return Ok(carroAluguel);
            }

            return NotFound("Não foi buscar por modelo ou id");

        }

    }
}
