
using System.ComponentModel.DataAnnotations.Schema;

namespace P02_FootballBetting.Data.Models
{
    public class PlayerStatistic
    {
        //properties for composit primary key -> make it in Fluent API
        public int GameId { get; set; }
        [ForeignKey(nameof(GameId))]
        public virtual Game Game { get; set; } = null!;
        public int PlayerId { get; set; }
        [ForeignKey(nameof(PlayerId))]
        public virtual Player Player { get; set; } = null!;

        //statistic info properties
        public byte ScoredGoals { get; set; } // Warning: Jugde may not be happy with byte

        public byte Assists { get; set; } // Same -||-

        public byte MinutesPlayed { get; set; } // Same -||-

        // TODO: create relations

    }
}
