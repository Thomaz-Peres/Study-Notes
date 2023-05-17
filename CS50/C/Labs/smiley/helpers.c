#include "helpers.h"

void colorize(int height, int width, RGBTRIPLE image[height][width])
{
    // Change all black pixels to a color of your choosing
    for(int i = 0; i < height; i++)
    {
        for(int i = 0; i < width; i++)
        {
            if(image.rgbtBlue == 0 )
            {
                image.rgbtBlue = 50;
            }
        }
    }
}
