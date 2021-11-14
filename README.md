# TP214E

Olivier Lamontagne
William Francoeur

Correction du bug:

Le bug vient du fait que le formulaire utilisé pour la pageCommande est un window. Puisqu’il y a déjà un mainWindow dans laquelle les pages pour l’inventaire et l’accueil sont hébergées, il est logique que le window des commandes doive plutôt être une page. On ne peut pas utiliser le navigationService.Navigate sur une fenêtre, on devrait plutôt utiliser un showDialog. 

Étapes de résolutions:

1) Changer héritage à page plutôt que window.

2) Dans le xaml, changer les balises de window à page, et remplacer les dimensions Width et Height par des designWidth et designHeight.

3) Changer le navigationService.Navigate dans la page d’accueil pour ouvrir le frmPageCommandes.

