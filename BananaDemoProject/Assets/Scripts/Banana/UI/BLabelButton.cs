using UnityEngine;
using System.Collections;
using System;

public class BLabelButton : FContainer, FSingleTouchable
{
	protected FAtlasElement _normalElement;
	protected FAtlasElement _overElement;
	protected FSprite _bg;
	protected FLabel _label;
	protected string _text;
	
	public event EventHandler OnTap;
	
	public BLabelButton (string text) : base()
	{
		_text = text;
		
		_normalElement = FEngine.atlasManager.GetElementWithName("YellowButton_normal.png");
		_overElement = FEngine.atlasManager.GetElementWithName("YellowButton_over.png");
		
		_bg = new FSprite(_normalElement.name);
		AddChild(_bg);
		
		_label = new FLabel("Franchise", _text);
		AddChild(_label);
		_label.color = new Color(0.45f,0.25f,0.0f,1.0f); 
	}
	
	override public void HandleAddedToStage()
	{
		base.HandleAddedToStage();	
		FEngine.touchManager.AddSingleTouchTarget(this);
	}
	
	override public void HandleRemovedFromStage()
	{
		base.HandleRemovedFromStage();	
		FEngine.touchManager.RemoveSingleTouchTarget(this);
	}
	
	public bool HandleSingleTouchBegan(FTouch touch)
	{
		Vector2 touchPos = _bg.GlobalToLocal(touch.position);
		
		if(_bg.localRect.Contains(touchPos))
		{
			_bg.element = _overElement;
			return true;	
		}
		
		return false;
	}
	
	public void HandleSingleTouchMoved(FTouch touch)
	{
		Vector2 touchPos = _bg.GlobalToLocal(touch.position);
		
		if(_bg.localRect.Contains(touchPos))
		{
			_bg.element = _overElement;	
		}
		else
		{
			_bg.element = _normalElement;	
		}
	}
	
	public void HandleSingleTouchEnded(FTouch touch)
	{
		_bg.element = _normalElement;
		
		Vector2 touchPos = _bg.GlobalToLocal(touch.position);
		
		if(_bg.localRect.Contains(touchPos))
		{
			BSoundPlayer.PlayClickSound();
			if(OnTap != null) OnTap(this, EventArgs.Empty);
		}
	}
	
	public void HandleSingleTouchCanceled(FTouch touch)
	{
		_bg.element = _normalElement;
	}
	
	
}

