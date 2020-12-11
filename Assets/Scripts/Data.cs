using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Data
{
    private static float joystickX = 0f; //X del joystick
    private static float joystickY = 0f; //Y del joystick

    //JOYSTICK DIRECTION
    public static float getJoyX(){return joystickX;}
    public static void setJoyX(float valor){joystickX = valor;}
    public static float getJoyY(){return joystickY;}
    public static void setJoyY(float valor){joystickY = valor;}
}