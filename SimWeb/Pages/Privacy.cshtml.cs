using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Application;
using Application.Maps;

//namespace Application;
namespace SimWeb.Pages;

public class PrivacyModel : PageModel
{
    public int Turn {get; }
    /*
    public SimulationHistory SetSimHistory()
    {
        SmallTorusMap map = new(8, 7);
        List<IMappable> mappables = [
            new Plant("Kaktus"),
        new Plant("Kliwia"),
        new Plant("Konwalia"),
        ];
        List<Point> points = [
            new(2,1),
        new(3,4),
        new(5,6),
        new(6,6)
            ];
        IMappable character = new Character("Ogrognik Karol");
        Point postCh = new(0, 0);
        string moves = "rludrludrludrludrlu";
        string seqmoves = "uuurdruuullrrrrdddd";
        Simulation sim = new(map, character, mappables, postCh,
            points, moves, seqmoves);
        //SimulationHistory slash = new( Turn, sim);
        
    }*/ 
    public void OnGet()
    {

    }
}
