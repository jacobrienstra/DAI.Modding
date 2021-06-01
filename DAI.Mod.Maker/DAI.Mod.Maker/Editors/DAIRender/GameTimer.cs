using System.Diagnostics;

namespace DAI.ModMaker.DAIRender {
    public class GameTimer {
        private readonly double _secondsPerCount;

        private double _deltaTime;

        private long _baseTime;

        private long _pausedTime;

        private long _stopTime;

        private long _prevTime;

        private long _currTime;

        private bool _stopped;

        public float DeltaTime => (float)_deltaTime;

        public float FrameTime { get; set; }

        public float TotalTime {
            get {
                if (_stopped) {
                    return (float)((double)(_stopTime - _pausedTime - _baseTime) * _secondsPerCount);
                }
                return (float)((double)(_currTime - _pausedTime - _baseTime) * _secondsPerCount);
            }
        }

        public GameTimer() {
            _secondsPerCount = 0.0;
            _deltaTime = -1.0;
            _baseTime = 0L;
            _pausedTime = 0L;
            _prevTime = 0L;
            _currTime = 0L;
            _stopped = false;
            _secondsPerCount = 1.0 / (double)Stopwatch.Frequency;
        }

        public void Reset() {
            _prevTime = (_baseTime = Stopwatch.GetTimestamp());
            _stopTime = 0L;
            _stopped = false;
        }

        public void Start() {
            long timestamp = Stopwatch.GetTimestamp();
            if (_stopped) {
                _pausedTime += timestamp - _stopTime;
                _prevTime = timestamp;
                _stopTime = 0L;
                _stopped = false;
            }
        }

        public void Stop() {
            if (!_stopped) {
                _stopTime = Stopwatch.GetTimestamp();
                _stopped = true;
            }
        }

        public void Tick() {
            if (_stopped) {
                _deltaTime = 0.0;
                return;
            }
            _currTime = Stopwatch.GetTimestamp();
            _deltaTime = (double)(_currTime - _prevTime) * _secondsPerCount;
            _prevTime = _currTime;
            if (_deltaTime < 0.0) {
                _deltaTime = 0.0;
            }
        }
    }
}
