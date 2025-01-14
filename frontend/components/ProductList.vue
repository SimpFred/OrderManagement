<template>
  <div>
    <h2 class="text-xl font-semibold mb-2">Produkter</h2>
    <table class="min-w-full bg-slate-100">
      <thead>
        <tr>
          <th
            class="py-2 px-4 border-b border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            Produkt
          </th>
          <th
            class="py-2 px-4 border-b border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            Antal
          </th>
          <th
            class="py-2 px-4 border-b border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            Pris
          </th>
          <th
            class="py-2 px-4 border-b border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            Summa
          </th>
        </tr>
      </thead>
      <tbody>
        <tr v-for="product in order.products" :key="product.id">
          <td class="py-2 px-4 border-b border-gray-200">{{ product.name }}</td>
          <td class="py-2 px-4 border-b border-gray-200">
            {{ product.quantity }}
          </td>
          <td class="py-2 px-4 border-b border-gray-200">
            {{ formatPrice(product.price) }} SEK
          </td>
          <td class="py-2 px-4 border-b border-gray-200">
            {{ formatPrice(product.quantity * product.price) }} SEK
          </td>
        </tr>
      </tbody>
      <tfoot>
        <tr class="border-t-2 border-gray-400">
          <td
            class="py-2 px-4 border-t border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            Totalt
          </td>
          <td
            class="py-2 px-4 border-t border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            {{
              order.products.reduce((sum, product) => sum + product.quantity, 0)
            }}
          </td>
          <td
            class="py-2 px-4 border-t border-gray-200 text-left text-sm font-semibold text-gray-800"
          ></td>
          <td
            class="py-2 px-4 border-t border-gray-200 text-left text-sm font-semibold text-gray-800"
          >
            {{ formatPrice(order.totalCost) }}
            SEK
          </td>
        </tr>
      </tfoot>
    </table>
  </div>
</template>

<script setup lang="ts">
import { defineProps } from "vue";
import type { Order } from "~/types";

defineProps<{ order: Order }>();
</script>
