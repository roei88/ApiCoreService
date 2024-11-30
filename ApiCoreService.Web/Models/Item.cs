﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace InfraSkillsPro.Models
{
    public class Item
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
