# Labo 3

## Module 320 - Programmer orienté objet

## Contexte

Vous êtes mandaté par Blizzard
pour travailler sur leur nouveau jeu
promis à un succès au moins aussi
grand que celui de World of
Warcraft. Vous allez devoir ajouter
des fonctionnalités à la version
actuelle et revoir l’équilibrage du
jeu.

## Consignes

1. Prendre connaissance du projet
   - Faites quelques parties de la version Beta
   - Passez en revue le diagramme de classe
   - Parcourez la structure du projet

2. Ajouter les équipements suivants au marché :
   - Sandales à crampons
     - Caractéristiques : PV, vitesse, force, agilité +10%
     - Prix : 150
   - Cape céleste
     - Caractéristiques : Agilité +50%, PV, vitesse et force -20%
     - Prix : 250
   - Cape de garde royal
     - Caractéristiques : PV et force +50%, vitesse et agilité -40%
     - Prix : 250

3. Ajouter la classe de héro suivante :
   - Voleur
     - Nom : Voleur
     - Caractéristiques : PV -50%, force -20%, vitesse +60% et agilité +60%
     - Arme de base :
       - Nom : Couteau de cuisine
       - Dégâts : 1 – 2
       - Nombre de coups : 1000

- L’IA du jeu doit pouvoir incarner cette nouvelle classe

4. Equilibrer le jeu :
   - Actuellement les armes et équipements appliquent des modifications sur les caractéristiques du
   personnage sous la forme de pourcentage. Par exemple un anneau de vie ajoute 10% de PV aux
   caractéristiques du personnage; avec une base à 100, il aurait donc 100 + 100 * 10% = 110 PV
   - Faites en sorte que tous les équipements et toutes les armes ajoutent des valeurs fixes. Par
   exemple l’anneau de vie ajoute 10 PV aux caractéristiques du personnage; avec une base à 100, il
   aurait donc 100 + 10 = 110 PV
   - Attention : les classes de héro appliquent également des modifications des caractéristiques sous
   forme de pourcentage ; ce comportement doit être conservé.
   - Adaptez le calcul des caractéristiques des personnages de façon à tenir compte de ces
   modifications faites aux équipements et armes. Le calcul se fait de la manière suivante:
     - On applique toutes les modifications de caractéristiques sous forme de valeur fixe
     - On applique toutes les modifications de caractéristique sous forme de pourcentage
     - Une caractéristique ne peut être inférieur à 1
     - Exemples avec une caractéristique de base à 100 :
       - Modification à valeur fixe +20, modification à pourcentage +50% : (100 + 20) * 1.5 = 180
       - Modification à valeur fixe -150, modification à pourcentage -20% : (100 – 150) * 0.8 = -40 → 1

## Délivrables

-  Code source :
  -  Format : zip
  - Contenu de l’archive : dossier complet de l’application console
  - Nom du fichier : classe - prénom nom - Labo 2 sources.zip
    - Exemple : INFO2A – Arthas Menethil – Labo3 sources.zip