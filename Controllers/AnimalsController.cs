using Microsoft.AspNetCore.Mvc;
using BackEnd.Data;
using BackEnd.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly AnimalContext _context;

    public AnimalsController(AnimalContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Animal>>> GetAnimals()
    {
        return await _context.Animals.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Animal>> GetAnimal(int id)
    {
        var animal = await _context.Animals.FindAsync(id);

        if (animal == null)
        {
            return NotFound();
        }

        return animal;
    }

    [HttpPost]
    public async Task<ActionResult<Animal>> PostAnimal(Animal animal)
    {
        _context.Animals.Add(animal);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutAnimal(int id, Animal animal)
    {
        if (id != animal.Id)
        {
            return BadRequest();
        }

        _context.Entry(animal).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimal(int id)
    {
        var animal = await _context.Animals.FindAsync(id);
        if (animal == null)
        {
            return NotFound();
        }

        _context.Animals.Remove(animal);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpPost("upload-audio")]
    public async Task<IActionResult> UploadAudio([FromForm] IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("No file uploaded.");

        var googleDriveService = new GoogleDriveService();
        var audioUrl = await googleDriveService.UploadFileAsync(file.OpenReadStream(), file.FileName, file.ContentType);

        if (string.IsNullOrEmpty(audioUrl))
            return StatusCode(500, "Audio upload failed.");

        return Ok(new { Url = audioUrl });
    }

    [HttpGet("audio/{cardId}")]
    public async Task<IActionResult> GetAudio(int cardId)
    {
        var animal = await _context.Animals.FindAsync(cardId);
        if (animal == null)
        {
            return NotFound();
        }

        // Assuming the audio URL is stored in the Animal model
        return Ok(new { Url = animal.AudioUrl });
    }
}
