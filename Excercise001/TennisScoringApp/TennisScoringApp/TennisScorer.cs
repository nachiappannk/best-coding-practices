using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisScoringApp
{
    public class TennisScorer
    {
        private int player1Points = 0;
        private int player2Points = 0;
        private string player1Name;
        private string player2Name;

        public TennisScorer(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == player1Name)
                player1Points += 1;
            else
                player2Points += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (player1Points == player2Points)
            {
                switch (player1Points)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;

                }
            }
            else if (player1Points >= 4 || player2Points >= 4)
            {
                var minusResult = player1Points - player2Points;
                if (minusResult == 1) score = $"Advantage to {player1Name}";
                else if (minusResult == -1) score = $"Advantage to {player2Name}";
                else if (minusResult >= 2) score = $"Win for {player1Name}";
                else score = $"Win for {player2Name}";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = player1Points;
                    else { score += "-"; tempScore = player2Points; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}
