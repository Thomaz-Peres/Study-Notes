## Agent build

é o agente de compilação, e temos dois tipos

- Microsoft Self-Hosted = hospedado pela microsoft
- Private (on premise) = criamos um servidor privado

## Agent Pool

conjunto de agent builds (nosso agent build é sempre vinculado a um agent pool)

- São chamados de **Microsoft-hosted agents (agentes hospedados pela microsoft)**
- Disponiveis apenas no Azure DevOps Service
- Microsoft é responsavel pela manutenção e atualização
- Sempre que um pipeline é executado é obtido uma VM nova, e são descartadas após o uso.

Existem agentes hospedados pela microsoft para os 3 sistemas operacionais, sendo eles Linux, Windows ou MacOS

- Windows 
    - windows-latest

- Linux
    - ubunto-latest

MacOS
    - MacOs-latest

# Self-hosted agents (agentes auto hospedados)

Esses agentes são de nossa responsabilidade

Instalamos eles nos nossos servidores e precisamos manter ele no ar, tendo total autonomia podendo utilizar nossos proprios recursos, sem filas para executar os pipelines

É uma instalação simples, e pode ser usado agentes em containers Docker.