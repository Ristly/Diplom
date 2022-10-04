using UnityEngine;


namespace Assets.Scripts
{
    public class DoubleClickClass
    {
        private float clicked = 0;
        private float clicktime = 0;
        private float clickdelay = 0.5f;

        public bool DoubleClick()
        {

            if (Input.GetMouseButtonDown(0))
            {

                clicked++;
                if (clicked == 1) clicktime = Time.time;
            }
            if (clicked > 1 && Time.time - clicktime < clickdelay)
            {

                clicked = 0;
                clicktime = 0;
                return true;
            }
            else if (clicked > 2 || Time.time - clicktime > 1) clicked = 0;
            return false;
        }
    }
}
