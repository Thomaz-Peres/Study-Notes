// #include <stdio.h>

// int main(void)
// {
// 	int numbers[] = {1, 2, 3};

// 	int i = 0;
// 	while(numbers[i])
// 	{
// 		printf("Number: %d -> Address: %p\n", numbers[i], &numbers[i]);
// 		i++;
// 	}
// }	


#include <stdio.h>

int main(void)
{
	char *s = "HI!";

	printf("%s\n", s);
	printf("%p\n", &s[0]);
	printf("%p\n", &s[1]);
	
	
	printf("%s\n", s);	 // HI!
	printf("%s\n", s+1); // I!
	printf("%s\n", s+2); // !
}	
