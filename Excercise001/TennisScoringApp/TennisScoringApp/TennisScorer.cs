using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

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
                    case 0: return "Love-All";
                    case 1: return "Fifteen-All";
                    case 2: return "Thirty-All";
                    default: return "Deuce";
                }
            }
            else if (player1Points >= 4 || player2Points >= 4)
            {
                var differenceInPoints = player1Points - player2Points;
                if (differenceInPoints == 1) return $"Advantage to {player1Name}";
                if (differenceInPoints == -1) return $"Advantage to {player2Name}";
                if (differenceInPoints >= 2) return $"Win for {player1Name}";
                return $"Win for {player2Name}";
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    if (i == 1) tempScore = player1Points;
                    else { score += "-"; tempScore = player2Points; }
                    score = GetPartScore(tempScore);
                }
            }
            return score;
        }

        private string GetPartScore(int point)
        {
            switch (point)
            {
                case 0: return "Love";
                case 1: return "Fifteen";
                case 2: return "Thirty";
                default: return "Forty";
            }
        }
    }
}
