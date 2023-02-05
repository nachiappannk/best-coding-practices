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
            if (player1Points == player2Points) return GetScoreWhenEqualPoints();
            if (player1Points > 3 || player2Points > 3) return GetScoreWhenAnyPlayerHasScopedMoreThan3Points();
            else
            {
                return $"{GetPartScore(player1Points)}-{GetPartScore(player2Points)}";
            }
        }

        private string GetScoreWhenAnyPlayerHasScopedMoreThan3Points()
        {
            if ((player1Points <= 3) && (player2Points <= 3)) throw new Exception("Method called when both player's points is not greater than 3");

            var differenceInPoints = player1Points - player2Points;
            if (differenceInPoints == 1) return $"Advantage to {player1Name}";
            if (differenceInPoints == -1) return $"Advantage to {player2Name}";
            if (differenceInPoints >= 2) return $"Win for {player1Name}";
            return $"Win for {player2Name}";
        }

        private string GetScoreWhenEqualPoints()
        {
            if (player1Points != player2Points) throw new Exception($"The method {nameof(GetScoreWhenEqualPoints)} called when score is not equal");
            switch (player1Points)
            {
                case 0: return "Love-All";
                case 1: return "Fifteen-All";
                case 2: return "Thirty-All";
                default: return "Deuce";
            }
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
