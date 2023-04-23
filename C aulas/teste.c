#include <stdio.h>

int main(void)
{
	int n = 50;
	int *p = &n;
	
	printf("Value of N: %d\n", n);
	printf("Address of n like 50: %p\n", p);
	printf("Address of p: %p\n", &p);

	*p = 20;

	printf("Value of N now: %d\n", n);
	printf("Address of n like 20: %p\n", p);
	printf("Address of p altering n value: %p\n", &p);	
}

