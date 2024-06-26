using Picture;
using UI;
using UnityEngine;
using Zenject;

namespace GameController
{
    public class GameController : IGameController, ITickable
    {
        private readonly TickableManager _tickableManager;
        private readonly MainCamera.MainCamera _camera;
        private readonly PictureController _pictureController;
        
        private const int Distance = 1000;
        private RaycastHit _hit;

        public GameController(
            TickableManager tickableManager,
            MainCamera.MainCamera camera,
            PictureController pictureController)
        {
            _tickableManager = tickableManager;
            _camera = camera;
            _pictureController = pictureController;
            _tickableManager.Add(this);
            Start();
        }

        public void Start()
        {
            _pictureController.SpawnPicture();
        }

        public void Restart()
        {
            throw new System.NotImplementedException();
        }

        public void Stop()
        {
            throw new System.NotImplementedException();
        }

        public void Tick()
        {
            if (Input.GetMouseButton(0))
            {
                TouchLogic();
            }
        }

        private void TouchLogic()
        {

            Ray ray = _camera.SceneCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction*1000);
            if (Physics.Raycast(ray, out hit,1000))
            {
                if (hit.transform)
                {
                    Debug.Log("Попал в объект: " + hit.transform.name);

                }
            }
        }
    }
}