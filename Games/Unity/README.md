# IK

- o IK ajuda na hora de fazer efeitos.
- Sera utilizado o ITA que é o (inverse cinematics).

- Sempre interessante colocar interações dentro das animações quando necessario.

## Utilizando o IK para a cabeça

- Codigo utilizado para olhar para um alvo
(SetLookAt, funciona apenas para a cabeça mexendo os braços mais abaixo).

```Csharp
private void OnAnimatorIK(int layerIndex)
{
    //  necessita de um valor para definir o efeito
    animator.SetLookAtWeight(1);
    //  passa a posição que preciso olhar
    animator.SetLookAtPosition(alvo.position);
}
```
- e depois é necessario ligar o IK no *Animator -> Layers -> icone de configaração do base layer, e ligar o IK*

## Utilizando o IK para os braços

- Para determinar o **animator.SetIKPosition**, é necessario determinar o **animator.SetIKPositionWeight**


- Utilizando o *animator.SetIKPositionWeight*
```Csharp
animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
```