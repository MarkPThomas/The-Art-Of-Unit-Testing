namespace Events
{
    public class Presenter
    {
        private readonly IView _view;
        private readonly ILogger _logger;

        public Presenter(IView view)
        {
            _view = view;
            _view.Loaded += OnLoaded;
        }

        public Presenter(IView view, ILogger logger)
        {
            _logger = logger;

            _view = view;
            _view.Loaded += OnLoaded;
            _view.ErrorOccurred += OnError;
        }

        private void OnLoaded()
        {
            _view.Render("Hello World");
        }

        private void OnError(string message)
        {
            _logger.LogError(message);
        }
    }
}
