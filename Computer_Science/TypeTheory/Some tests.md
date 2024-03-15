Some judments try myself

| Formal notation for juddments    | Description                                                                            |
| -------------------------------- | -------------------------------------------------------------------------------------- |
| $\Gamma \vdash bool$  Type       | $bool$ is a type (under assumptions $\Gamma$).                                         |
| $\Gamma \vdash x : bool$         | $x$ is a term of type $bool$ (under assumptions $\Gamma$)                              |
| $\Gamma \vdash bool_1 = bool_2$  | Type $bool_1$ is equal to type $bool_2$ (under assumptions $\Gamma$)                   |
| $\Gamma \vdash x_1 = x_2 : bool$ | Terms $t_1$ and $t_2$ are both of type $T$ and are equal (under assumptions $\Gamma$). |

```csharp
internal class Judment
{
	public class bool Type { get; set; }
}

internal class 
```

interface Judgement {
    assumptions: Assumption[];
}

interface Assumption {
    variable: string;
    type: string;
}

interface TypeJudgement extends Judgement {
    type: string;
}

interface TermTypeJudgement extends Judgement {
    term: string;
    type: string;
}

interface TypeEqualityJudgement extends Judgement {
    type1: string;
    type2: string;
}

interface TermEqualityJudgement extends Judgement {
    term1: string;
    term2: string;
    type: string;
}
