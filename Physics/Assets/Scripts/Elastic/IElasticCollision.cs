namespace Physics.Elastic
{
    public interface IElasticCollision
    {
        /// <summary>
        /// Calculate the velocity of the first object
        /// </summary>
        /// <param name="mass1">Mass of the first object</param>
        /// <param name="mass2">Mass of the second object</param>
        /// <param name="velocity1">Object's velocity when collision occurred</param>
        /// <returns></returns>
        float CalculateVelocityFirstObject(float mass1, float mass2, float velocity1);

        /// <summary>
        /// Calculate the velocity of the second object
        /// </summary>
        /// <param name="mass1">Mass of the first object</param>
        /// <param name="mass2">Mass of the second object</param>
        /// <param name="velocity1">Object's velocity when collision occurred</param>
        /// <returns></returns>
        float CalculateVelocitySecondObject(float mass1, float mass2, float velocity1);
    }
}