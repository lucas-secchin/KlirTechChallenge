import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-checkout-test',
  templateUrl: './promotion-test.component.html'
})
export class PromotionTestComponent {
  public products: Product[];
  public shoppingCartList: ShoppingCartItem[] = new Array();

  constructor(http: HttpClient, @Inject('BASE_API_URL') baseUrl: string) {
    http.get<Product[]>(baseUrl + 'product').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }

  addProduct(product: Product) {
    var item = this.shoppingCartList.find(obj => { return obj.product.id === product.id });

    if (item != null) {
      item.quantity += 1;
      this.calculatePromotion(item);
    }
    else {
      this.shoppingCartList.push({
        product: product,
        quantity: 1,
        totalPrice: product.price,
        promotionApplied: false,
      });
    }
  };

  addItemQuantity(item: ShoppingCartItem) { 
    item.quantity += 1;

    this.calculatePromotion(item);
  };

  removeItemQuantity(item: ShoppingCartItem) {
    
    if (item.quantity == 1) {
      const index: number = this.shoppingCartList.indexOf(item);
      if (index !== -1) {
        this.shoppingCartList.splice(index, 1);
      }
    }
    else {
      item.quantity -= 1;
    }
    this.calculatePromotion(item);
  };

  calculatePromotion(item: ShoppingCartItem) {
    switch (item.product.promotionType) {
      case PromotionType.BuyOneGetOneFree:
        var div = Math.floor(item.quantity / 2);
        var divRem = item.quantity % 2;

        item.totalPrice = (div * item.product.price) + (divRem * item.product.price);
        break;
      case PromotionType.ThreeFor10Euros:
        var div = Math.floor(item.quantity / 3);
        var divRem = item.quantity % 3;

        item.totalPrice = (div * 10) + (divRem * item.product.price);
        break;
      default:
        item.totalPrice = item.quantity * item.product.price;
        break;
    }
    item.promotionApplied = div > 0;
  }

  getTotalPrice() {
    var total = 0;
    this.shoppingCartList.forEach(function (item) { total += item.totalPrice; });
    return total;
  }
}

enum PromotionType { BuyOneGetOneFree = 0, ThreeFor10Euros = 1 };

interface Product {
  id: number;
  name: string;
  price: number;
  promotionName: string;
  promotionType: PromotionType;
}

interface ShoppingCartItem {
  product: Product;
  quantity: number;
  totalPrice: number;
  promotionApplied: boolean;
}

