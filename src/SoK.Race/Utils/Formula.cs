using System;

namespace SoK.Races.Utils
{
    public static class Formula
    {
        /// <summary>
        /// R = kv^2
        /// </summary>
        /// <param name="runner"></param>
        /// <returns></returns>
        public static double Drag(double dragCoefficient, double velocity)
        {
            return dragCoefficient * Math.Pow(velocity, 2);
        }

        /// <summary>
        /// a = (F -R)/m
        /// </summary>
        /// <param name="runner"></param>
        /// <param name="drag"></param>
        /// <returns></returns>
        public static double Acceleration(double force, double drag, int mass)
        {
            return (force - drag) / mass;
        }

        /// <summary>
        /// // v = at
        /// </summary>
        /// <param name="acc"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public static double Velocity(double acc, double time)
        {
            return acc * time;    
        }

        /// <summary>
        /// s = ut + (at^2/2)
        /// </summary>
        /// <param name="velocity"></param>
        /// <param name="time"></param>
        /// <param name="acc"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static double Displacement(double velocity, double time, double acc)
        {
            return (velocity * time) + (acc * Math.Pow(time, 2) / 2); 
        }
    }
}
