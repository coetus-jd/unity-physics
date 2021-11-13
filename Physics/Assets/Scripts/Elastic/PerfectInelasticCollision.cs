namespace Physics.Elastic
{
    public class PerfectInelasticCollision : IElasticCollision
    {
        public float CalculateVelocityFirstObject(
            float mass1,
            float mass2,
            float velocity1
        ) => (mass1 / (mass1 + mass2)) * velocity1;

        public float CalculateVelocitySecondObject(
            float mass1,
            float mass2,
            float velocity1
        ) => (mass1 / (mass1 + mass2)) * velocity1;
    }
}