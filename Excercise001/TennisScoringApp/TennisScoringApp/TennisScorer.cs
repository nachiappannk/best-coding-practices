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
            if (IsEqualNumberOfPoints()) return GetScoreWhenEqualPoints();
            if (IsAnyPlayerGreaterThan3Points()) return GetScoreWhenAnyPlayerHasScopedMoreThan3Points();
            return $"{GetPartScore(player1Points)}-{GetPartScore(player2Points)}";
        }

        private bool IsAnyPlayerGreaterThan3Points()
        {
            if (player1Points > 3) return true;
            if (player2Points > 3) return true;
            return false;
        }

        private bool IsNoPlayerGreaterThan3Points()
        {
            return !IsAnyPlayerGreaterThan3Points();
        }

        private bool IsEqualNumberOfPoints()
        {
            return player1Points == player2Points;
        }

        private string GetScoreWhenAnyPlayerHasScopedMoreThan3Points()
        {
            if (IsNoPlayerGreaterThan3Points()) throw new Exception("Method called when both player's points is not greater than 3");

            var diff = player1Points - player2Points;
            if (diff == 1) return $"Advantage to {player1Name}";
            if (diff == -1) return $"Advantage to {player2Name}";
            if (diff >= 2) return $"Win for {player1Name}";
            return $"Win for {player2Name}";
        }

        private string GetScoreWhenEqualPoints()
        {
            if (!IsEqualNumberOfPoints()) throw new Exception($"The method {nameof(GetScoreWhenEqualPoints)} called when score is not equal");
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
