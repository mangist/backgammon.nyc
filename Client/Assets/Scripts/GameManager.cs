using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private List<Checker> checkers = new List<Checker>();
    private Dictionary<int, Point> points = new Dictionary<int, Point>();

    public static GameManager Instance { get; private set; }

	// Use this for initialization
	void Start () {

        var whiteStart = new Vector3(-0.05f, 0.3f, 0);
        var blackStart = new Vector3(0.05f, 0.3f, 0);

        var white_checker = GameObject.FindGameObjectsWithTag(Tags.WhiteChecker).First();
        var black_checker = GameObject.FindGameObjectsWithTag(Tags.BlackChecker).First();

        // Setup the local checker pieces
        checkers.Clear();
        for (int i = 0; i < 15; i ++)
        {
            // Spawn a new checker for each side
            var white = GameObject.Instantiate(white_checker, whiteStart, Random.rotation);
            white.name = string.Format("WhiteChecker_{0}", i + 1);

            var black = GameObject.Instantiate(black_checker, blackStart, Random.rotation);
            black.name = string.Format("BlackChecker_{0}", i + 1);

            // Keep a reference to our checker objects
            checkers.Add(new Checker { Player = Player.White, Object = white });
            checkers.Add(new Checker { Player = Player.Black, Object = black });

            // Move higher with the start positions (approx height of the checker)
            whiteStart.y += Checker.Width;
            blackStart.y += Checker.Width;
        }

        // Delete the template objects
        GameObject.Destroy(white_checker);
        GameObject.Destroy(black_checker);

        var startHeightOfCheckers = 0.03f;

        // Setup points list for the game board
        var lowerRight = new Vector3(0.1522381f, startHeightOfCheckers, 0.124089f);
        var lowerLeft = new Vector3(-0.1522381f, startHeightOfCheckers, 0.124089f);

        var topLeft = new Vector3(-0.1522381f, startHeightOfCheckers, -0.124089f);
        var topRight = new Vector3(0.1522381f, startHeightOfCheckers, -0.124089f);

        var position = lowerRight;

        // Bottom right quadrant
        for (int i = 0; i < 6; i++)
        {
            var pointPosition = new Vector3(position.x, position.y, position.z);
            points.Add(i+1, new Point (i+1, pointPosition));

            position.x -= Point.Width;
        }

        // Bottom left quadrant
        position = lowerLeft;
        for (int i = 11; i > 5; i--)
        {
            var pointPosition = new Vector3(position.x, position.y, position.z);
            points.Add(i+1, new Point(i + 1, pointPosition));

            position.x += Point.Width;
        }

        position = topLeft;
        // Second side of the board
        for (int i = 12; i < 18; i ++)
        {
            var pointPosition = new Vector3(position.x, position.y, position.z);
            points.Add(i + 1, new Point(i + 1, pointPosition));

            position.x += Point.Width;
        }

        position = topRight;
        // Second side of the board
        for (int i = 23; i > 17; i--)
        {
            var pointPosition = new Vector3(position.x, position.y, position.z);
            points.Add(i + 1, new Point(i + 1, pointPosition));
            position.x -= Point.Width;
        }

        // Debug - print out points on the board
        foreach (var p in points)
        {
            Debug.Log(string.Format("Point {0} created at x:{1} y:{2} z:{3}", p.Value.Number, p.Value.Position.x, p.Value.Position.y, p.Value.Position.z));
        }
        // Keep a singleton instance of the manager
        Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void MoveChecker(Checker checker, int toPosition)
    {
        var toPoint = GetPoint(toPosition);

        // First see if this checker belongs in any existing point
        // and remove it
        var currentPoint = points.Values.SingleOrDefault(p => p.Checkers.Contains(checker));
        if (currentPoint != null)
        {
            // NB: Assume we are always taking the top checker (so we don't have to move the others down)
            currentPoint.RemoveChecker(checker);
        }

        // Add to destination point
        toPoint.AddChecker(checker);
        
    }

    private Point GetPoint(int position)
    {
        return points[position];
    }

    public void ResetBoard()
    {
        // Put the pieces in the correct starting position
        var whites = checkers.Where(c => c.Player == Player.White).ToList();
        var blacks = checkers.Where(c => c.Player == Player.Black).ToList();

        // Setting up the board starting with the lower right corner
        MoveChecker(blacks[0], 1);
        MoveChecker(blacks[1], 1);

        MoveChecker(whites[0], 6);
        MoveChecker(whites[1], 6);
        MoveChecker(whites[2], 6);
        MoveChecker(whites[3], 6);
        MoveChecker(whites[4], 6);

        MoveChecker(whites[5], 8);
        MoveChecker(whites[6], 8);
        MoveChecker(whites[7], 8);

        MoveChecker(blacks[2], 12);
        MoveChecker(blacks[3], 12);
        MoveChecker(blacks[4], 12);
        MoveChecker(blacks[5], 12);
        MoveChecker(blacks[6], 12);
        
        MoveChecker(whites[8], 13);
        MoveChecker(whites[9], 13);
        MoveChecker(whites[10], 13);
        MoveChecker(whites[11], 13);
        MoveChecker(whites[12], 13);

        MoveChecker(blacks[7], 17);
        MoveChecker(blacks[8], 17);
        MoveChecker(blacks[9], 17);

        MoveChecker(blacks[10], 19);
        MoveChecker(blacks[11], 19);
        MoveChecker(blacks[12], 19);
        MoveChecker(blacks[13], 19);
        MoveChecker(blacks[14], 19);

        MoveChecker(whites[13], 24);
        MoveChecker(whites[14], 24);
    }
}
