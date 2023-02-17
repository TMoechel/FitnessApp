using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessApp.Activity
{
    public class ClimbActivity : Activity
    {
        public ClimbActivity(double distance, double timeTaken, string? feeling) : base(distance, timeTaken, feeling)
        {
        }
    }
}