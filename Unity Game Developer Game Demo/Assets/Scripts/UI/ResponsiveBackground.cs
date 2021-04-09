using UnityEngine;

/// <summary>
/// Class that makes the background responsive to most of the devices that I have tested this game on.
/// This class is needed because the background can not be part of the UI, since it overlaps the 2D sprites if the canvas is set to
/// Overlay, which you want if you need responsive UI.
/// </summary>
public class ResponsiveBackground : MonoBehaviour
{
    //reference to the sprite renderer
    private SpriteRenderer _spriteRenderer;
    
    //variable for the camera size
    private Vector2 _cameraSize;
    
    //variable for the sprite size
    private Vector2 _spriteSize;
    
    //variable for the y position of the camera
    private float _cameraHeight;
    
    //variable for how much we need to scale the given sprite
    private Vector2 _scale;
    private void Awake()
    {
        //get the sprite renderer reference
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        //calculate the height of the camera by squaring the ortographic scale
        _cameraHeight = Camera.main.orthographicSize * 2;
        
        //calculate the size by the aspect * the height and the height
        _cameraSize = new Vector2(Camera.main.aspect * _cameraHeight, _cameraHeight);
        
        //get the sprite's size
        _spriteSize = _spriteRenderer.sprite.bounds.size;

        //scale the sprite
        _scale = transform.localScale;
        
        //change the scale based on the rotation 
        if (_cameraSize.x >= _cameraSize.y)
        {
            //landscape rotation
            _scale *= _cameraSize.x / _spriteSize.x;
        }
        else
        {   
            //portrait rotation
            _scale *= _cameraSize.y / _spriteSize.y;
        }
        
        //reset the position of the sprite
        transform.position = Vector2.zero;
        
        //change the sprite local rotation to the scale that has been calulated
        transform.localScale = _scale;
    }
}
