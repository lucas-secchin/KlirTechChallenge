# KlirTechChallenge
Tech Challenge to apply for a position at Klir

In this challenge, I developed a simple API using .NET Core and some unit tests using xUnit. I also developed a simple single-page web application using Angular to test some promotion rules.

**API Endpoints**
 * ``` base_url/product ```
 * ``` base_url/shoppingcart/checkout ```

For the last endpoint, you must pass a list of items as a parameter, using JSON format, for example:

```json
[
{
	"Product": {
        "Id": 1,
        "Name": "PRODUCT A",
        "Price": 20,
        "CurrentPromotion":{
            "Id": 1,
            "Name": "Buy 1 Get 1 Free",
            "Type": 0
        }
    },
	"Quantity": 4
},
{
	"Product": {
        "Id": 1,
        "Name": "PRODUCT B",
        "Price": 4,
        "CurrentPromotion":{
            "Id": 1,
            "Name": "3 for 10 Euro",
            "Type": 1
        }
    },
	"Quantity": 4
}
]
```

**It was awesome!** Thanks for the opportunity!
Hope to talk to you soon!
