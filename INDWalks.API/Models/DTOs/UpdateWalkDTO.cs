﻿namespace INDWalks.API.Models.DTOs
{
    public class UpdateWalkDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionID { get; set; }
    }
}
