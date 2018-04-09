(function (app) {

    var serverConnection = "http://localhost:52578/";

    var bookController = function ($scope, $http, $window, $location) {
        $scope.type = "Novo Livro";
        $scope.isEdit = false;
        $scope.typOrder = false;
        $scope.language = "PT";
        $scope.hasMessage = false;
        $scope.loading = true;
        
        $http({
            method: 'GET',
            url: serverConnection + 'api/values?value=Title&type=ASC'
        }).then(function (success) {
            $scope.loading = false;
            $scope.books = success.data;
        }, function () { });

        if ($location.absUrl().split("idbook=")[1] != undefined) {
            $scope.isEdit = true;

            $http({
                method: 'GET',
                url: serverConnection + 'api/values/' + $location.absUrl().split("idbook=")[1]
            }).then(function (success) {
                $scope.type = "Editando Livro";
                $scope.title = success.data.Title;
                $scope.description = success.data.Description;
                $scope.author = success.data.Author;
                $scope.tradutor = success.data.Tradutor;
                $scope.launch = new Date(success.data.Launch);
                $scope.price = success.data.Price;
                $scope.language = success.data.Language;
                $scope.publishingCompany = success.data.PublishingCompany;
                $scope.width = success.data.Width;
                $scope.height = success.data.Height;
            }, function () { });
        }

        $scope.edit = function (index) {
            $window.location.href = '/Book/NewBook/idbook=' + index;
        };

        $scope.delete = function (index) {
            $http({
                method: 'DELETE',
                url: serverConnection + 'api/values/' + index
            }).then(function () {
                $http({
                    method: 'GET',
                    url: serverConnection + 'api/values?value=Title&type=ASC'
                }).then(function (success) {
                    $scope.books = success.data;
                }, function () { });
            }, function () { });
        };

        $scope.ordena = function (type) {

            var order = $scope.typOrder === false ? "DESC" : "ASC";

            $scope.typOrder = !$scope.typOrder;

            $http({
                method: 'GET',
                url: serverConnection + 'api/values?value=' + type + "&type=" + order
            }).then(function (success) {
                $scope.books = success.data;
            }, function () { });
        }

        function isNumber(n) {
            return !isNaN(parseFloat(n)) && isFinite(n);
        }

        $scope.save = function () {

            var modelBook = {
                Title: $scope.title,
                Description: $scope.description,
                Author: $scope.author,
                Tradutor: $scope.tradutor,
                Launch: $scope.launch,
                Price: $scope.price,
                Language: $scope.language,
                PublishingCompany: $scope.publishingCompany,
                Width: $scope.width,
                Height: $scope.height
            };

            if (modelBook.Title == undefined) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "O tiítulo é obrigatório!";
                return;
            }
            if (modelBook.Description == undefined) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "A descrição é obrigatória!";
                return;
            }
            if (modelBook.Author == undefined) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "O autor é obrigatório!";
                return;
            }
            if (modelBook.Launch == undefined) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "A data de lançamento é obrigatória!";
                return;
            }
            if (modelBook.Language == undefined) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "A linguagem é obrigatória!";
                return;
            }
            if (!isNumber(modelBook.Price == undefined ? 0 : modelBook.Price)) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "O campo preço é númerico!";
                return;
            }
            if (!isNumber(modelBook.Width == undefined ? 0 : modelBook.Width)) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "O campo largura é númerico!";
                return;
            }
            if (!isNumber(modelBook.Height == undefined ? 0 : modelBook.Height)) {
                $("html, body").animate({ scrollTop: 0 }, "slow");
                $scope.hasMessage = true;
                $scope.message = "O campo altura é númerico!";
                return;
            }

            if ($scope.isEdit) {
                $http.put(serverConnection + 'api/values/' + $location.absUrl().split("idbook=")[1], modelBook).then(function () { $window.location.href = '/Book/ListBook'; }, function () { alert("Houve um problema ao atualizar o novo livro."); });
            }
            else {
                $http.post(serverConnection + 'api/values', modelBook).then(function () { $window.location.href = '/Book/ListBook'; }, function () { alert("Houve um problema ao inserir o novo livro."); });
            }
        };
    };

    app.directive('ngConfirmClick',
        [
            function() {
                return {
                    link: function(scope, element, attr) {
                        var msg = attr.ngConfirmClick || "Are you sure?";
                        var clickAction = attr.confirmedClick;
                        element.bind('click',
                            function() {
                                if (window.confirm(msg)) {
                                    scope.$eval(clickAction);
                                }
                            });
                    }
                };
            }
        ]);

    app.controller('bookController', bookController);

}(angular.module("library", [])))
