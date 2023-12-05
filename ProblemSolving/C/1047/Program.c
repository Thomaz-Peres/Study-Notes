#include <stdio.h>

int main() {
    int hi, mi, hf, mf, AUX1, AUX2;
    scanf("%i %i %i %i",&hi, &mi, &hf, &mf);

    if ((hi == hf) && (mi == mf)) {
        AUX1 = 24;
        AUX2 = 0;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    } else if ((hi == hf) && (mi > mf)) {
        AUX1 = 23;
        AUX2 = 60 - mi + mf;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    } else if (hi == hf) {
        AUX1 = 0;
        AUX2 = mf - mi;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    } else if ((hf > hi) && (mf < mi)) {
        AUX1 = hf - hi - 1;
        AUX2 = 60 - mi + mf;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    } else if ((hi <= hf) && (mi <= mf)) {
        AUX1 = hf - hi;
        AUX2 = mf - mi;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    } else if ((hi > hf) && (mi > mf)) {
        AUX1 = 23 - hi + hf;
        AUX2 = 60 - mi + mf;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    } else if ((hi > hf) && (mi <= mf)) {
        AUX1 = 24 - hi + hf;
        AUX2 = mf - mi;
        printf("O JOGO DUROU %i HORA(S) E %i MINUTO(S)\n", AUX1, AUX2);
    }
    return 0; 
}
