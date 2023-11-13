#include <stdio.h>
#include <math.h>

int main() 
{
    double raio;
    scanf("%lf",&raio);

    double pi = 3.14159;
    raio *= raio;
    double area = round((pi * raio) * 10000) / 10000;

    printf("A=%.4lf\n", area);

    return 0; 
}
