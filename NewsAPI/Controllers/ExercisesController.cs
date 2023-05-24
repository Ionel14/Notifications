using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsAPI.Model;
using System;
using System.ComponentModel.DataAnnotations;

namespace NewsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExercisesController : Controller
    {
        private static List<string> strings = new List<string> { "wew", "maw", "wawawa" };
        
        /// <summary>
        /// Get static strings
        /// </summary>
        /// <returns></returns>
        [HttpGet("static")]
        public ActionResult GetStaticStrings()
        {
            return Ok(strings);
        }

        /// <summary>
        /// Replace in static strings at position index
        /// </summary>
        /// <param name="index"></param>
        /// <param name="newString"></param>
        /// <returns></returns>

        [HttpPut("/{index}")]
        public ActionResult UpdateStatic([FromRoute] int index, [FromBody] string newString)
        {
            if (index > strings.Count)
            {
                return BadRequest("Index out of bounds");
            }
            if (newString == null)
            {
                return BadRequest("String is null");
            }
            strings[index] = newString;
            return Ok(strings);
        }

        /// <summary>
        /// Delete static string
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpDelete("{position}")]
        public ActionResult DeleteStaticString(int position)
        {
            if (position > strings.Count)
            {
                return BadRequest("Index out of bounds");
            }
            strings.RemoveAt(position);
            return Ok();
        }

        /// <summary>
        /// Get sum of num1, num2
        /// </summary>
        /// <param name="exercise"></param>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns></returns>
        [HttpGet("/{exercise}")]
        public ActionResult GetExercise([FromRoute]string exercise, [FromQuery][Required] double num1, [FromQuery][Required] double num2)
        {
            return Ok($"{exercise}: {num1 + num2}");
        }

        /// <summary>
        /// Sum of numbers
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult GetSum([FromQuery][Required] List<double> numbers)
        {
            if (numbers == null)
            {
                return BadRequest("The list is null");
            }
            if (numbers.Count == 0)
            {
                return BadRequest("The list is empty");
            }
            return Ok(numbers.Sum());
        }
    }
}
