﻿using Microsoft.EntityFrameworkCore;

 namespace CognitiveServicesTemplate.Persistence.Contract.Context
{
    public interface IDbContext
    {
        DbContext Instance { get; }
    }
}