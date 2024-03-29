﻿using System.Collections.Generic;
using PhoneDirectory.Domain.Entities;

namespace PhoneDirectory.UnitTests.DataHelpers
{
    public static class DivisionHelper
    {
        public static Division GetOneDefaultEntity()
        {
            return new Division
            {
                Name = "TestDivision1", ChildDivisions = new List<Division>()
                {
                    new() {Name = "TestNestedDivisionLevel1",
                        ChildDivisions = new List<Division>()
                        {
                            new () {Name = "TestNestedDivisionLevel2"}
                        }}
                }
            };
        }

        public static Division GetOneCreatedEntity()
        {
            return new Division
            {
                Name = "CreatedDivisionDto1", ChildDivisions = new List<Division>()
                {
                    new Division() {Name = "CreatedNestedDivisionDto1" }
                }
            };
        }

        public static IEnumerable<Division> GetManyDefaultEntities()
        {
            return new List<Division>()
            {
                new() { Name = "TestDivision2" },
                new() { Name = "TestDivision3" },
                new() { Name = "TestDivision4" },
                new() { Name = "TestDivision5" },
            };
        }
    }
}