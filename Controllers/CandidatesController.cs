using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

namespace MyWebApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CandidatesController : ControllerBase
{
    private static List<Candidate> _candidates = new()
    {
        new Candidate
        {
            Id = "1",
            Name = "Ionel Fieraru",
            Description = "Ionel Fieraru, zis și \"Primarul Beton\", are 15 ani de experiență în a mesteca politicile ca pe shaorma la 3 dimineața. A fost consilier local, primar și DJ de ocazie. Vrea joburi, reforme, aer mai verde și Wi-Fi gratis în pivnițe. Crede în cooperare transpartinică, dar mai ales în mici cu muștar duminica.",
            Image = "https://images.unsplash.com/photo-1507003211169-0a1dd7228f2d?w=150&h=150&fit=crop&crop=face",
            Party = "AUR"
        },
        new Candidate
        {
            Id = "2",
            Name = "Sorina Jăncuța",
            Description = "Sorina, CEO la 3 firme și mamă spirituală a imprimantelor 3D, a zis \"gata cu vechiul, hai cu smart city și brânză bio!\" Vrea digitalizare totală, antreprenoriat la micul dejun și aplicații guvernamentale care chiar funcționează. A fost văzută o dată certându-se cu un server public în latină.",
            Image = "https://images.unsplash.com/photo-1494790108755-2616b612b786?w=150&h=150&fit=crop&crop=face",
            Party = "Independent"
        },
        new Candidate
        {
            Id = "3",
            Name = "Mihăiță Cenușă",
            Description = "Mihăiță a fost educator, lider de scară de bloc și campion la dat cu părerea în ședințe de cartier. Platforma lui are 3 piloni: școală, sănătate și floricele gratis la bibliotecă. Are sute de voluntari, toți crescuți cu poezii motivaționale și zacuscă de la bunica.",
            Image = "https://images.unsplash.com/photo-1472099645785-5658abf4ff4e?w=150&h=150&fit=crop&crop=face",
            Party = "PSD"
        },
        new Candidate
        {
            Id = "4",
            Name = "Emilia Rodiță",
            Description = "Emilia, cunoscută printre pacienți drept \"Doamna cu injecția blândă\", vrea spitale curate, medici fericiți și pacienți care nu mai stau la coadă ca la concert. A lucrat peste tot, de la cabinete de cartier la ambulanțe teleportate. Campania ei vine cu pastile de umor și promisiuni sterile.",
            Image = "https://images.unsplash.com/photo-1438761681033-6461ffad8d80?w=150&h=150&fit=crop&crop=face",
            Party = "PNL"
        },
        new Candidate
        {
            Id = "5",
            Name = "Dănuț Tankson",
            Description = "Dănuț a fost prin toate – războaie, patrule, și probabil un reality show cu dresaj de câini. Vrea ordine, siguranță și ca toată lumea să învețe să salute ca în armată. Iubește veteranii, respectă legile și are cel puțin 4 bastoane simbolice la el oricând.",
            Image = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?w=150&h=150&fit=crop&crop=face",
            Party = "PNL"
        }
    };

    // Random data for generating candidates
    private static readonly string[] RomanianNames = {
        "Vasile Popescu", "Maria Ionescu", "Gheorghe Dumitrescu", "Ana Stanescu", "Ion Vasilescu",
        "Elena Marin", "Petre Radu", "Cristina Munteanu", "Alexandru Neagu", "Diana Popa",
        "Mihai Tudor", "Roxana Dragomir", "Stefan Badea", "Gabriela Lupu", "Andrei Cazacu",
        "Larisa Dumitru", "Florin Barbu", "Simona Toma", "Dragos Olteanu", "Adriana Rusu",
        "Bogdan Stoica", "Carmen Grigore", "Valentin Mocanu", "Laura Buzatu", "Marius Enache",
        "Nicoleta Sandu", "Tudor Dobre", "Monica Iacob", "Razvan Toma", "Alina Dumitrache"
    };

    private static readonly string[] RomanianParties = {
        "Partidul Verde Românesc", "Alianța pentru Viitor", "Mișcarea pentru Democrație",
        "Partidul Libertății", "Coaliția pentru Schimbare", "Uniunea Națională",
        "Partidul Progresului", "Alianța Democratică", "Mișcarea Civică",
        "Partidul pentru Dezvoltare", "Coaliția pentru România", "Uniunea Liberală",
        "Partidul pentru Dreptate", "Alianța pentru Democrație", "Mișcarea pentru Libertate"
    };

    private static readonly string[] Descriptions = {
        "Candidat cu experiență în administrația publică, dedicat îmbunătățirii serviciilor pentru cetățeni și promovării transparenței în guvernare.",
        "Antreprenor cu viziune pentru dezvoltarea economică durabilă, susține inovația și crearea de locuri de muncă în tehnologii verzi.",
        "Educator pasionat de reforma sistemului de învățământ, promovează accesul egal la educație și modernizarea infrastructurii școlare.",
        "Medic cu experiență în sistemul de sănătate, lucrează pentru îmbunătățirea accesului la serviciile medicale și reducerea listelor de așteptare.",
        "Inginer cu expertiză în infrastructură, susține dezvoltarea transportului public și modernizarea rețelelor de utilități.",
        "Avocat specializat în dreptul administrativ, promovează justiția socială și protecția drepturilor cetățenilor.",
        "Cercetător în domeniul tehnologiilor informaționale, susține digitalizarea administrației publice și securitatea cibernetică.",
        "Economist cu viziune pentru creșterea economică durabilă, promovează investițiile în tehnologii verzi și economia circulară.",
        "Sociolog pasionat de problemele sociale, lucrează pentru reducerea inegalităților și promovarea incluziunii sociale.",
        "Arhitect cu viziune pentru dezvoltarea urbană durabilă, susține construcția de locuințe accesibile și spații verzi."
    };

    /// <summary>
    /// Get all candidates
    /// </summary>
    [HttpGet]
    public ActionResult<IEnumerable<Candidate>> GetCandidates()
    {
        return Ok(_candidates);
    }

    /// <summary>
    /// Get candidate by ID
    /// </summary>
    [HttpGet("{id}")]
    public ActionResult<Candidate> GetCandidate(string id)
    {
        var candidate = _candidates.FirstOrDefault(c => c.Id == id);
        if (candidate == null)
        {
            return NotFound($"Candidate with ID {id} not found");
        }
        return Ok(candidate);
    }

    /// <summary>
    /// Create a new candidate
    /// </summary>
    [HttpPost]
    public ActionResult<Candidate> CreateCandidate([FromBody] Candidate candidate)
    {   
        if (string.IsNullOrWhiteSpace(candidate.Name))
        {
            return BadRequest("Name is required");
        }

        candidate.Id = (_candidates.Count > 0 ? _candidates.Max(c => int.Parse(c.Id)) : 0) + 1.ToString();
        _candidates.Add(candidate);
        
        return CreatedAtAction(nameof(GetCandidate), new { id = candidate.Id }, candidate);
    }

    /// <summary>
    /// Update an existing candidate
    /// </summary>
    [HttpPut("{id}")]
    public ActionResult<Candidate> UpdateCandidate(string id, [FromBody] Candidate candidate)
    {
        var existingCandidate = _candidates.FirstOrDefault(c => c.Id == id);
        if (existingCandidate == null)
        {
            return NotFound($"Candidate with ID {id} not found");
        }

        existingCandidate.Name = candidate.Name;
        existingCandidate.Description = candidate.Description;
        existingCandidate.Image = candidate.Image;
        existingCandidate.Party = candidate.Party;

        return Ok(existingCandidate);
    }

    /// <summary>
    /// Delete a candidate
    /// </summary>
    [HttpDelete("{id}")]
    public ActionResult DeleteCandidate(string id)
    {
        var candidate = _candidates.FirstOrDefault(c => c.Id == id);
        if (candidate == null)
        {
            return NotFound($"Candidate with ID {id} not found");
        }

        _candidates.Remove(candidate);
        return NoContent();
    }

    /// <summary>
    /// Generate a random candidate
    /// </summary>
    [HttpPost("generate-random")]
    public ActionResult<Candidate> GenerateRandomCandidate()
    {
        var random = new Random();
        var randomName = RomanianNames[random.Next(RomanianNames.Length)];
        var randomParty = RomanianParties[random.Next(RomanianParties.Length)];
        var randomDescription = Descriptions[random.Next(Descriptions.Length)];
        
        var newCandidate = new Candidate
        {
            Id = (_candidates.Count > 0 ? _candidates.Max(c => int.Parse(c.Id)) : 0) + 1.ToString(),
            Name = randomName,
            Party = randomParty,
            Description = randomDescription,
            Image = ""
        };

        _candidates.Add(newCandidate);
        return CreatedAtAction(nameof(GetCandidate), new { id = newCandidate.Id }, newCandidate);
    }
} 