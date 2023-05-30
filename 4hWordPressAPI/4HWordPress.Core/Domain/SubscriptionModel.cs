using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4HWordPress.Core.Domain
{
    public class SubscriptionModel
    {
        /// <summary>
        /// Gets or sets the SubscriptionsId.
        /// </summary>
        /// <value>
        /// The SubscriptionsId.
        /// </value>
        public int? SubscriptionsId { get; set; }

        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        /// <value>
        /// The Id.
        /// </value>
        public int? Id { get; set; }

        /// <summary>
        /// Gets or sets the Parent_id.
        /// </summary>
        /// <value>
        /// The Parent_id.
        /// </value>
        public int? Parent_id { get; set; }

        /// <summary>
        /// Gets or sets the Status.
        /// </summary>
        /// <value>
        /// The Status.
        /// </value>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the Order_key.
        /// </summary>
        /// <value>
        /// The Order_key.
        /// </value>
        public string? Order_key { get; set; }

        /// <summary>
        /// Gets or sets the Number.
        /// </summary>
        /// <value>
        /// The Number.
        /// </value>
        public int? Number { get; set; }

        /// <summary>
        /// Gets or sets the Currency.
        /// </summary>
        /// <value>
        /// The Currency.
        /// </value>
        public string? Currency { get; set; }

        /// <summary>
        /// Gets or sets the Date_created.
        /// </summary>
        /// <value>
        /// The Date_created.
        /// </value>
        public DateTime? Date_created { get; set; }

        /// <summary>
        /// Gets or sets the Date_modified.
        /// </summary>
        /// <value>
        /// The Date_modified.
        /// </value>
        public DateTime? Date_modified { get; set; }

        /// <summary>
        /// Gets or sets the Customer_id.
        /// </summary>
        /// <value>
        /// The Customer_id.
        /// </value>
        public int? Customer_id { get; set; }

        /// <summary>
        /// Gets or sets the Payment_method.
        /// </summary>
        /// <value>
        /// The Payment_method.
        /// </value>
        public string? Payment_method { get; set; }

        /// <summary>
        /// Gets or sets the Transaction_id.
        /// </summary>
        /// <value>
        /// The Transaction_id.
        /// </value>
        public string? Transaction_id { get; set; }

        /// <summary>
        /// Gets or sets the Date_completed.
        /// </summary>
        /// <value>
        /// The Date_completed.
        /// </value>
        public DateTime? Date_completed { get; set; }

        /// <summary>
        /// Gets or sets the Date_paid.
        /// </summary>
        /// <value>
        /// The Date_paid.
        /// </value>
        public DateTime? Date_paid { get; set; }

        /// <summary>
        /// Gets or sets the Line_items_id.
        /// </summary>
        /// <value>
        /// The Line_items_id.
        /// </value>
        public int? Line_items_id { get; set; }

        /// <summary>
        /// Gets or sets the Line_items_name.
        /// </summary>
        /// <value>
        /// The Line_items_name.
        /// </value>
        public string? Line_items_name { get; set; }

        /// <summary>
        /// Gets or sets the Line_items_product_id.
        /// </summary>
        /// <value>
        /// The Line_items_product_id.
        /// </value>
        public string? Line_items_product_id { get; set; }

        /// <summary>
        /// Gets or sets the Line_items_quantity.
        /// </summary>
        /// <value>
        /// The Line_items_quantity.
        /// </value>
        public int? Line_items_quantity { get; set; }

        /// <summary>
        /// Gets or sets the Line_items_price.
        /// </summary>
        /// <value>
        /// The Line_items_price.
        /// </value>
        public string? Line_items_price { get; set; }

        /// <summary>
        /// Gets or sets the Line_items_total.
        /// </summary>
        /// <value>
        /// The Line_items_total.
        /// </value>
        public string? Line_items_total { get; set; }

        /// <summary>
        /// Gets or sets the Billing_period.
        /// </summary>
        /// <value>
        /// The Billing_period.
        /// </value>
        public string? Billing_period { get; set; }

        /// <summary>
        /// Gets or sets the Billing_interval.
        /// </summary>
        /// <value>
        /// The Billing_interval.
        /// </value>
        public string? Billing_interval { get; set; }

        /// <summary>
        /// Gets or sets the Start_date.
        /// </summary>
        /// <value>
        /// The Start_date.
        /// </value>
        public DateTime? Start_date { get; set; }

        /// <summary>
        /// Gets or sets the Next_payment_date.
        /// </summary>
        /// <value>
        /// The Next_payment_date.
        /// </value>
        public DateTime? Next_payment_date { get; set; }


    }
}
