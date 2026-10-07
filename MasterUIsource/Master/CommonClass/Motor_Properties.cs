using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master.CommonClass
{
    public class Motor_Properties
    {
        #region Input params
        public int index { get; set; }                      // axis index   
        public string name { get; set; }                      // axis name    
        public double negative_limit { get; set; }            // axis soft limit 
        public double positive_limit { get; set; }            // axis soft limit 
        public double min_velocity { get; set; }              // min velocity
        public double max_velocity { get; set; }              // max velocity
        public double min_acceleration { get; set; }          // min acceleration
        public double max_acceleration { get; set; }          // max acceleration
        public double min_deceleration { get; set; }         // min deaccleration
        public double max_deceleration { get; set; }         // max deaccleration        
        public int timeout_sec { get; set; }                  // timeout for travel reaching a position
        #endregion      
       
    }
}
