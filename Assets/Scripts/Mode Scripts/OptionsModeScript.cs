using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OptionsModeScript : MonoBehaviour {

	Slider effectsSlider;
	Slider musicSlider;

	//--------------------------------------------------------------------------//
	//	Start
	//--------------------------------------------------------------------------//
	void Start ()
	{
		float valFix;

		effectsSlider	=	GameObject.Find
							("EffectsVolSlider").GetComponent<Slider>	();

		musicSlider		=	GameObject.Find
							("MusicVolSlider").GetComponent<Slider>		();

		if (ModeManager.volSettings.areEffectsMuted)
			effectsSlider.value = 0.0F;
		else
			effectsSlider.value = ModeManager.volSettings.effectsVol;

		if (ModeManager.volSettings.isMusicMuted)
			musicSlider.value = 0.0F;
		else
			musicSlider.value = ModeManager.volSettings.musicVol;
	}
	
	//--------------------------------------------------------------------------//
	//	EffectsSliderChange
	//--------------------------------------------------------------------------//
	public void	EffectsSliderChange(float newVal)
	{
		if (ModeManager.volSettings.areEffectsMuted)
		{
			if (newVal == 0.0F)		return;
			ModeManager.volSettings.areEffectsMuted = false;
		}
		ModeManager.volSettings.effectsVol = newVal;
	}
	//--------------------------------------------------------------------------//
	//	EffectsMuteClickEvent
	//--------------------------------------------------------------------------//
	public void EffectsMuteClickEvent ()
	{
		if (ModeManager.volSettings.areEffectsMuted)
		{
			ModeManager.volSettings.areEffectsMuted = false;
			effectsSlider.value = ModeManager.volSettings.effectsVol;
		}
		else
		{
			ModeManager.volSettings.areEffectsMuted = true;
			effectsSlider.value = 0;
		}
	}
	//--------------------------------------------------------------------------//
	//	MusicSliderChange
	//--------------------------------------------------------------------------//
	public void	MusicSliderChange(float newVal)
	{
		if (ModeManager.volSettings.isMusicMuted)
		{
			if (newVal == 0.0F)		return;
			ModeManager.volSettings.isMusicMuted = false;
		}
		ModeManager.volSettings.musicVol = newVal;
	}
	//--------------------------------------------------------------------------//
	//	MusicMuteClickEvent
	//--------------------------------------------------------------------------//
	public void MusicMuteClickEvent ()
	{
		if (ModeManager.volSettings.isMusicMuted)
		{
			ModeManager.volSettings.isMusicMuted = false;
			musicSlider.value = ModeManager.volSettings.musicVol;
		}
		else
		{
			ModeManager.volSettings.isMusicMuted = true;
			musicSlider.value = 0;
		}
	}
	//--------------------------------------------------------------------------//
	//	CloseClickEvent
	//--------------------------------------------------------------------------//
	public void CloseClickEvent ()
	{
		ModeManager.GoBack ();
	}
}
