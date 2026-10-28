# Exercício 01 

```bash
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#> dotnet run .\AmbienteEstacionamento\Program.cs
Microsoft Windows NT 10.0.26200.0
11.0.0
C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#
```
# Exercício 02
#### Em C# rodar um comando direto para o processador prenderia o meu software a um sistema operacial. Com o # CLR e o CIL/IL isso é possível independente do sistema.
- O IL é converte todo o código um grande pacote universal, se mandamos o código direto do IL para o processador vai da ruim porque ele não vai entender nada é ai que entra o CRL.

- O CLR é um motor de execuções obrigatório, então no momento que o IL manda para o CPU o JIT (tradutor interno) é chamado do dentro do CLR convertendo os pacotes do IL para binário porque assim o processador consegue entende o que o codigo escreveu! 

# Exercício 03
Escrita

#### 1\. Arquivos Gerados no Build (`bin/Debug/...`)

Ao executar `dotnet build`, o MSBuild compila o projeto e gera os principais arquivos na pasta de saída:

| Arquivo | Descrição |
| --- | --- |
| `.dll` | Contém o código compilado em IL e os metadados do programa. |
| `.pdb` | Armazena informações utilizadas na depuração do código. |
| `.deps.json` | Registra as dependências do projeto. |
| `.runtimeconfig.json` | Define as configurações necessárias para iniciar o runtime .NET. |
| `.exe` (opcional) | Executável nativo que inicia o programa no Windows. |

#### 2\. Papel dos Componentes do .NET

- **.NET SDK / MSBuild:** Orquestra o processo de compilação e geração dos arquivos.
- **Roslyn:** Compila o código C# para IL (_Intermediate Language_).
- **BCL:** Fornece bibliotecas e tipos fundamentais, como `System.Console`.
- **CLR:** Gerencia a execução do programa, utilizando o JIT para converter IL em código nativo e o Garbage Collector para gerenciar a memória.

#### 3\. Ciclo de Vida do Programa

O programa passa pelas seguintes etapas:

`Program.cs` → **Roslyn** → **IL (.dll)** → **CLR / JIT** → **Código nativo** → **CPU**

# Exercício 04
```
==================================================
           CALCULADORA DE TARIFA
==================================================

Tempo total informado: 135 minutos
Valor por hora:        R$ 12,50
Teto diário fixo:      R$ 50,00
--------------------------------------------------
2
Tempo de permanência:  2h 15min
Horas tarifadas:       3 hora(s)
Valor total a cobrar:  R$ 37,50
--------------------------------------------------
Resultado: O valor calculado (R$ 37,50) é MENOR que o teto diário fixo (R$ 50,00).
==================================================
```

# Exercício 05
```
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#\ClassificadorPermanencia> dotnet run .\Program.cscls
Digite o total de minutos estacionado: 0
Erro: O tempo de permanência não pode ser negativo ou Zero
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#\ClassificadorPermanencia> dotnet run .\Program.cscls
Digite o total de minutos estacionado: 5
Classificação: rotativa curta
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#\ClassificadorPermanencia> dotnet run .\Program.cscls
Digite o total de minutos estacionado: 300
Classificação: rotativa padrão
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#\ClassificadorPermanencia> dotnet run .\Program.cscls
Digite o total de minutos estacionado: 500
Classificação: diária
```

# Exercício 06
```
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#\ClassificadorPermanencia>dotnet run -- .\Program.cs
Digite o total de minutos estacionado (-1: encerrar): 45
Classificação: rotativa curta
Digite o total de minutos estacionado (-1: encerrar): 125
Classificação: rotativa padrão
Digite o total de minutos estacionado (-1: encerrar): 405
Classificação: diária
Digite o total de minutos estacionado (-1: encerrar): 0
Erro: O tempo de permanência não pode ser negativoou Zero
Digite o total de minutos estacionado (-1: encerrar): -2
Erro: O tempo de permanência não pode ser negativoou Zero
Digite o total de minutos estacionado (-1: encerrar): -1

--- Total de Veículos por Categoria ---
Rotativa curta:  1
Rotativa padrão: 1
Diária:          1
PS C:\Users\vazma\Desktop\faculdade-estudos\Faculdade-Infnet_GIT\Fundamentos_de_desenvolvimento_C#\ClassificadorPermanencia>
```

# Exercício 07
