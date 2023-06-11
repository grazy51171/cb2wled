

# CB2WLED

Petit programme fait à rapidement pour le fun.

Fait clignoter une guirlande WLED en fonction de tip dans Chaturbate ou si il y a un message "blink" dans le chat.

## Compilation

```
dotnet publish -c Release
```

## Préparation de la guirlande

Ce programme utilise deux presets de WLED. Un pour l'état flash et l'autre pour l'état. Il faut donc créer deux presets avec les couleurs que vous souhaitez.
Pour l'état normal il faut atribuer le preset 100 et pour l'état flash le preset 110.


## Utilisation

Celà utilise l'API Events API JSON feed  pour récupérer les tips et les messages du chat. Il faut donc récuperer l'url en bas de la page "Mon Profil/Paramètres et confidentialité"

cb2wled https://eventsapi.chaturbate.com/events/tonlogin/xyzefsdlkfjsdlfjlds/ http://ipWLED/


## TODO

- [ ] Rendre le programme plus générique point de vue id de preset
- [	] Rendre le code plus propre pour la partie WLED


