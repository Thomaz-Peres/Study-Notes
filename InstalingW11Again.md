## I'm installing windows again, and the backup the windows say he does, not work.

So, i need to install many things again, and I need to remember in steps

Windowns Terminal ->

    Microsoft store

[Win-Debloat](https://github.com/LeDragoX/Win-Debloat-Tools)

PWSH ->

    winget search Microsoft.PowerShell

    winget install --id Microsoft.Powershell.Preview --source winget

[Font Fira Code](https://github.com/ryanoasis/nerd-fonts/releases/download/v3.1.1/FiraCode.zip)

OH-my-posh ->

    winget install JanDeDobbeleer.OhMyPosh -s winget

    $env:Path += ";C:\Users\user\AppData\Local\Programs\oh-my-posh\bin"

PowerShell Profile ->

```powershell
oh-my-posh init pwsh --config "$env:POSH_THEMES_PATH\honukai.omp.json" | Invoke-Expression

Set-Alias -Name k -Value kubectl
Set-Alias -Name v -Value nvim
Set-Alias -Name code -Value 'code-insiders'

Set-Alias lvim 'C:\Users\name\.local\bin\lvim.ps1'

# Import the Chocolatey Profile that contains the necessary code to enable
# tab-completions to function for `choco`.
# Be aware that if you are missing these lines from your profile, tab completion
# for `choco` will not function.
# See https://ch0.co/tab-completion for details.
$ChocolateyProfile = "$env:ChocolateyInstall\helpers\chocolateyProfile.psm1"
if (Test-Path($ChocolateyProfile)) {
  Import-Module "$ChocolateyProfile"
}
```

Git ->

    winget install --id Git.Git -e --source winget

    git config --global user.email email
    git config --global user.name "name"

SSH ->

    1. Win(CMD, powershell not work) ->

            Get-Service -Name ssh-agent | Set-Service -StartupType Manual

            Start-Service ssh-agent

            ssh-add c:/Users/YOU/.ssh/id_ed25519

    2. Linux (wsl) ->

            $ eval "$(ssh-agent -s)"

            ssh-add ~/.ssh/id_ed25519

Dotnet ->

    winget install Microsoft.DotNet.SDK.6
    winget install Microsoft.DotNet.Runtime.6
    winget install Microsoft.DotNet.AspNetCore.6


Installing WSL ->