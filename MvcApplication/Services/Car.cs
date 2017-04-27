namespace MvcApplication.Services
{
    public class Car : ICar
    {
        private IEngine _engine;

        public Car(IEngine engine)
        {
            this._engine = engine;
        }

        public string Start()
        {
            return this._engine.StartEngine();
        }
    }
}