Problably I will do a dotfiles in future for my ArchWSL and my Arch Personal (I not sure if windows has this, I will take a look and probably will done one too)

## I'm installing windows again, and the backup the windows say he does, not work.

If the windows using to muuch run, check 'System Configuration -> Services -> Disable somethings'

pacman -Qm -> List packages installed

So, i need to install many things again, and I need to remember in steps

[Font Fira Code](https://github.com/ryanoasis/nerd-fonts/releases/download/v3.1.1/FiraCode.zip)

Windowns Terminal ->

    Microsoft store

    https://windowsterminalthemes.dev/

    (Normally TokyoNight or Moonlight II)

    Put the Fira Code as the font

[Win-Debloat](https://github.com/LeDragoX/Win-Debloat-Tools)

PWSH ->

    winget search Microsoft.PowerShell

    winget install --id Microsoft.Powershell.Preview --source winget

OH-my-posh ->

    winget install JanDeDobbeleer.OhMyPosh -s winget

    $env:Path += ";C:\Users\user\AppData\Local\Programs\oh-my-posh\bin"

[Pwsh profile](https://github.com/Thomaz-Peres/dotfiles/blob/main/powershell/Microsoft.PowerShell_profile.ps1)

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

            cp -r /mnt/c/Users/<username>/.ssh ~/.ssh

            sudo chmod -R 700 .ssh
            sudo chmod -R 600 .ssh/*

            eval "$(ssh-agent -s)"

            ssh-add ~/.ssh/id_ed25519
            ssh -T git@github.com

Dotnet ->

    winget install Microsoft.DotNet.SDK.6
    winget install Microsoft.DotNet.Runtime.6
    winget install Microsoft.DotNet.AspNetCore.6

Install SQL ->

    (https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

    In the folder where you installed, go to -> "\SQL2022\ExpressAdv_ENU\1033_ENU_LP\x64\Setup\x64\SQLLOCALDB.MSI"

    and install the SQLLOCALDB.MSI

    OR

    By Docker.

    And Azure Data Studio

Installing WSL ->

    wsl --install

    https://wsldl-pg.github.io/ArchW-docs/How-to-Setup/

    After all steps

    sudo pacman -S git yarn npm cargo base-devel

    clone yay (into /tmp folder) - (https://github.com/Jguer/yay)

    After yay

    You can install with pacman too, the zsh, whatever.
    yay -S zsh asdf-vm open-ssh bat exa procs tokei htop tealdeer grex rmesg zoxide neofetch

    For the plugins after `open-ssh`, you can use cargo:
        cargo install bat exa procs tokei htop tealdeer grex rmesg zoxide delta

    Change shell bash to zsh -> chsh -s /usr/bin/zsh

    Put the cargo path

    export PATH=$HOME/.local/bin:$HOME/.cargo/bin:$PATH

    Let install powerlevel10k (https://github.com/romkatv/powerlevel10k?tab=readme-ov-file#arch-linux)

    Reopen the archWSL window.

    ZSH plugins ->

    https://github.com/zsh-users/zsh-autosuggestions/blob/master/INSTALL.md

    Creata folder .zsh -> git clone https://github.com/zsh-users/zsh-autosuggestions ~/.zsh/zsh-autosuggestions

    add in .zshrc -> source ~/.zsh/zsh-autosuggestions/zsh-autosuggestions.zsh


    After this, the aliases:

    alias ls="exa --icons"
    alias bat="bat --style=auto"
    alias code="code-insiders"

    Configuring asdf

        ls /opt
        ls /opt/asdf-vm
        source /opt/asdf-vm/asdf.sh
		
		put this in .zshrc (yes I forget) source /opt/asdf-vm/asdf.sh
		

Problably Optional ->

    https://learn.microsoft.com/en-us/azure/storage/common/storage-use-azurite?tabs=github%2Cblob-storage

After all this, let's install docker on windows normally, and after this in WSL, use `yay -S docker`
