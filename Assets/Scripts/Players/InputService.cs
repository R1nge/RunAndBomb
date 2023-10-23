using System;

namespace Players
{
    public class InputService
    {
        private bool _inputEnabled;
        public event Action<bool> OnInputEnableStateChanged;

        public bool InputEnabled
        {
            get => _inputEnabled;
            private set
            {
                _inputEnabled = value;
                OnInputEnableStateChanged?.Invoke(_inputEnabled);
            }
        }

        public void Enable() => InputEnabled = true;

        public void Disable() => InputEnabled = false;
    }
}